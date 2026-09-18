# Security Guide: Local Credential Encryption via Windows DPAPI

**Date:** 2026-08-03  
**Target Skill:** `security-engineer`  

## 🎯 Overview
Revit Add-ins storing sensitive credentials (e.g. Azure Connection Strings, API Keys, DB Passwords) in local JSON configuration files in `%APPDATA%` **MUST NEVER** save raw plain-text strings.

All sensitive fields must be encrypted using **Windows Data Protection API (DPAPI)** (`System.Security.Cryptography.ProtectedData`).

---

## 🔐 Implementation Standard (`SecurityUtils.cs`)

```csharp
using System;
using System.Security.Cryptography;
using System.Text;

public static class SecurityUtils
{
    /// <summary>
    /// Encrypts a plain-text string using Windows DPAPI for current user.
    /// </summary>
    public static string EncryptString(string plainText)
    {
        if (string.IsNullOrEmpty(plainText)) return string.Empty;

        try
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedBytes);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error encrypting sensitive data with DPAPI", ex);
            return plainText;
        }
    }

    /// <summary>
    /// Decrypts a base64 DPAPI encrypted string for current user.
    /// </summary>
    public static string DecryptString(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText)) return string.Empty;

        try
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = ProtectedData.Unprotect(cipherBytes, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        catch (Exception ex)
        {
            TelemetryLogger.LogError("Error decrypting sensitive data with DPAPI", ex);
            return cipherText;
        }
    }
}
```

---

## 🔒 JSON Model Serialization Pattern

In data entity models:
- Serialize `EncryptedConnectionString` to JSON.
- Decorate `ConnectionString` with `[JsonIgnore]` so decrypted values never hit disk.

```csharp
public class FamilySourceItemModel
{
    public string EncryptedConnectionString { get; set; } = string.Empty;

    [JsonIgnore]
    public string ConnectionString
    {
        get => string.IsNullOrEmpty(EncryptedConnectionString) ? string.Empty : SecurityUtils.DecryptString(EncryptedConnectionString);
        set => EncryptedConnectionString = string.IsNullOrEmpty(value) ? string.Empty : SecurityUtils.EncryptString(value);
    }
}
```

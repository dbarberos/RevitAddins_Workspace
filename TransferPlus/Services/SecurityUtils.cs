using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace TransferPlus.Services;

public static class SecurityUtils
{
    /// <summary>
    /// Sanitizes input to prevent common injection attacks (XSS, SQLi, etc.).
    /// </summary>
    public static string SanitizeInput(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;
        
        // Remove potential script tags
        string sanitized = Regex.Replace(input, @"<[^>]*>", string.Empty);
        
        // Trim to a reasonable length to prevent buffer overflow/DoS
        if (sanitized.Length > 200) sanitized = sanitized.Substring(0, 200);
        
        return sanitized.Trim();
    }

    /// <summary>
    /// Validates if the string is a safe name for a tab or filter.
    /// </summary>
    public static bool IsSafeInput(string input)
    {
        if (string.IsNullOrEmpty(input)) return true;
        
        // Check for common malicious patterns
        if (input.Contains("..") || input.Contains("/") || input.Contains("\\")) return false;
        
        return true;
    }

    /// <summary>
    /// Encrypts a plain-text string using Windows DPAPI (ProtectedData) for current user.
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

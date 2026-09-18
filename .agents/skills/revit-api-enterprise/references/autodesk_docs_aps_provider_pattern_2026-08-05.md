# Architecture Reference: Autodesk Construction Cloud (ACC / APS) User-Friendly OAuth 2.0 PKCE Pattern

**Date:** 2026-08-05  
**Domain:** Enterprise Integrations / APS Cloud / User-Friendly OAuth 2.0 PKCE Loopback  
**Target Skill:** `revit-api-enterprise`  

---

## 🎯 Architectural Summary

When building enterprise Revit add-ins that connect to **Autodesk Construction Cloud (ACC / BIM 360 / APS)**:

1. **UX Best Practice (Zero Raw Tokens):**
   End users MUST NOT be asked to enter raw Access or Refresh Tokens manually. Provide a prominent **`🔑 Sign In with Autodesk Account`** button.

2. **Automated OAuth 2.0 PKCE Flow:**
   - Generate SHA-256 PKCE `code_verifier` and `code_challenge`.
   - Launch official Autodesk sign-in URL: `https://developer.api.autodesk.com/authentication/v2/authorize`.
   - Start local `HttpListener` on `http://localhost:8989/callback/` to capture authorization code.
   - Exchange code for tokens via `POST /authentication/v2/token`.
   - Fetch user profile (`GET /userprofile/v1/users/@me`) to display `UserName (Email)`.

3. **DPAPI Security:**
   Tokens stored in `family_sources.json` MUST be encrypted via DPAPI (`SecurityUtils`).

4. **Decoupled Provider Contract (`IFamilyProvider`):**
   Core UI interacts strictly with `IFamilyProvider` (`GetFamiliesAsync`, `TransferFamilyAsync`).

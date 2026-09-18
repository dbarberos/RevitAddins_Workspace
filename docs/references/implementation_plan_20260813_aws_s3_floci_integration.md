# Implementation Plan: AWS S3 Source Integration (Floci & Official AWS)

Integration of AWS S3 as a cloud family provider for Revit add-in `TransferPlus`. Supports both local development using **Floci / LocalStack** (`http://localhost:4566`) and **Official AWS S3** (`https://s3.amazonaws.com`).

---

## 📋 Confirmation of Required Input Fields in UI

The AWS S3 configuration form (`AwsS3SourceWindow.xaml`) includes explicit input controls for all required connection parameters:
1. **Name**: Descriptive source label (e.g., *"My AWS S3 Families"* or *"Floci Local S3"*).
2. **BucketName**: S3 Bucket identifier (e.g., `"familias-revit"`).
3. **Region**: AWS region code (e.g., `"eu-west-1"`, `"us-east-1"`).
4. **EndpointUrl**: Editable ComboBox (`IsEditable="True"`) with quick-select presets:
   - `http://localhost:4566` *(Floci / LocalStack local development)*
   - `https://s3.amazonaws.com` *(AWS S3 Real)*
5. **AccessKey**: Access key ID (`"test"` for Floci, or actual AWS IAM Access Key ID).
6. **SecretKey**: Secret access key (`"test"` for Floci, or actual AWS IAM Secret Key). **Encrypted automatically on disk via DPAPI**.
7. **RootPath**: Optional prefix directory path inside the bucket.
8. **Active**: Checkbox to enable/disable the source.

---

## ⚡ Connection Test Specification (`TestConnectionAsync`)

When clicking **⚡ Test Connection** in the `AwsS3SourceWindow` dialog:
1. Creates an `IAmazonS3` client via `S3ClientFactory.Create(model)` using:
   - `ServiceURL` set to the entered `EndpointUrl`.
   - `ForcePathStyle = true` automatically enabled when pointing to local/Floci endpoints (`localhost`, `127.0.0.1`, `:4566`).
   - `RegionEndpoint` derived from `Region`.
   - Decrypted `AccessKey` and `SecretKey`.
2. Executes a minimal S3 test call (`ListBucketsAsync` / `ListObjectsV2Async` for `BucketName`).
3. Detects execution mode:
   - **Floci Mode** if `EndpointUrl` contains `localhost`, `127.0.0.1`, or port `4566`.
   - **AWS Real Mode** if `EndpointUrl` points to `amazonaws.com` or custom production endpoint.
4. Feedback dialog & status:
   - **Success**: Displays *"Conectado correctamente a Floci (AWS local)."* or *"Conectado correctamente a AWS S3 real."*
   - **Failure**: Displays error dialog:
     ```text
     No se pudo conectar a S3.

     Modo: Floci (AWS local) [o AWS S3 real]
     Detalle: <Excepción>
     ```

---

## Proposed Code Structure

### Dependencies
#### [MODIFY] [TransferPlus.csproj](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/TransferPlus.csproj)
- Add `<PackageReference Include="AWSSDK.S3" Version="3.7.*" />`.

---

### Data Models & Services

#### [MODIFY] [FamilySourceItemModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Models/FamilySourceItemModel.cs)
- Verified `FamilySourceType.AwsS3`.
- Properties: `BucketName`, `Region`, `EncryptedAccessKey`, `EncryptedSecretKey`, `AccessKey` (DPAPI), `SecretKey` (DPAPI).
- Updated `SourceDescription` getter: `AWS S3: {BucketName}/{RootPath}`.

#### [NEW] [S3ClientFactory.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/S3ClientFactory.cs)
- Builds `IAmazonS3` with `AmazonS3Config`:
  - `ServiceURL = model.EndpointUrl`
  - `ForcePathStyle = model.EndpointUrl.Contains("localhost") || model.EndpointUrl.Contains("127.0.0.1") || model.EndpointUrl.Contains(":4566")`
  - `RegionEndpoint = RegionEndpoint.GetBySystemName(model.Region)`

#### [NEW] [AwsS3StorageService.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/AwsS3StorageService.cs)
- `TestConnectionAsync(model)`: validates connectivity and returns `(success, message, isFloci)`.
- `GetAvailableFamiliesAsync(model)`: lists `.rfa` objects in bucket.
- `DownloadFamilyBlobAsync(model, key, localTempPath)`: downloads `.rfa` to local cache.

#### [NEW] [AwsS3StorageFamilyProvider.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/AwsS3StorageFamilyProvider.cs)
- `IFamilyProvider` implementation for S3 sources.

#### [MODIFY] [FamilyProviderFactory.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Services/Providers/FamilyProviderFactory.cs)
- Register `AwsS3StorageFamilyProvider` for `FamilySourceType.AwsS3`.

---

### UI Windows & ViewModels

#### [NEW] [AwsS3SourceViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/AwsS3SourceViewModel.cs)
- ViewModel for AWS S3 source configuration window.
- Bound properties: `Name`, `BucketName`, `Region`, `EndpointUrl`, `AccessKey`, `SecretKey`, `RootPath`, `IsActive`, `SignedInStatus`, `EndpointPresets` (`http://localhost:4566` & `https://s3.amazonaws.com`).
- Commands: `TestConnectionCommand`, `OkCommand`, `CancelCommand`.

#### [NEW] [AwsS3SourceWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/AwsS3SourceWindow.xaml)
#### [NEW] [AwsS3SourceWindow.xaml.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/AwsS3SourceWindow.xaml.cs)
- Window layout with inputs for all required parameters and editable Endpoint URL ComboBox.

#### [MODIFY] [AzureStorageSourceViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/AzureStorageSourceViewModel.cs)
- Add `EndpointPresets` list: `http://127.0.0.1:10000` (Azurite) and `https://core.windows.net` (Azure official).

#### [MODIFY] [AzureStorageSourceWindow.xaml](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/Views/AzureStorageSourceWindow.xaml)
- Replace EndpointUrl TextBox with editable ComboBox (`IsEditable="True"`).

#### [MODIFY] [FamilySourcesViewModel.cs](file:///c:/Users/david.barbero/Documents/DOCUMENTOS/ALTEN/Workbench/RevitAddins_Workspace/RevitAddins_Workspace/TransferPlus/ViewModels/FamilySourcesViewModel.cs)
- Add & Edit actions open `AwsS3SourceWindow` when `SelectedSourceType == FamilySourceType.AwsS3`.

---

## Verification Plan

### Automated Build
- Run `dotnet build` Debug.R24 to ensure 0 compilation errors.

### Manual Verification
1. Open `Family sources settings` dialog, click **Add**, select **AWS S3**.
2. Verify all inputs exist: Name, BucketName, Region, EndpointUrl (ComboBox), AccessKey, SecretKey, RootPath, Active.
3. Select `http://localhost:4566` or `https://s3.amazonaws.com`, click **⚡ Test Connection**.
4. Confirm success dialog displays Floci vs AWS real mode correctly.
5. Open `Azure Storage` settings and verify EndpointUrl ComboBox presents `http://127.0.0.1:10000` and `https://core.windows.net`.

# AzureFunctionsDemo

## Setup

### Install dotnet Project and Item-Templates

    dotnet new --install Microsoft.Azure.WebJobs.ProjectTemplates::3.0.10405
    dotnet new --install Microsoft.Azure.WebJobs.ItemTemplates::3.0.10405

### Install Azure-Functions-Core-Tools

    choco install azure-functions-core-tools

### Install Azure-Functions-CLI

    Invoke-WebRequest -Uri https://aka.ms/installazurecliwindows -OutFile .\AzureCLI.msi; Start-Process msiexec.exe -Wait -ArgumentList '/I AzureCLI.msi /quiet'

### Create Principal for secrets.AZURE_CREDENTIALS

    az ad sp create-for-rbac --name "AzureFunctionsDemo" --sdk-auth

## Make

    dotnet new func
    dotnet new http
    dotnet build
    func start --script-root src\bin\Debug\netcoreapp3.0

## Setup Build & Deploy Pipeline

    https://www.aaron-powell.com/posts/2020-01-10-deploying-azure-functions-with-github-actions/
    Thanks! 

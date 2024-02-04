# Function to display menu and get user input
function Show-Menu {
    Clear-Host
    Write-Host "====================================================="
    Write-Host "Entity Framework Core Migration Helper `n"
    Write-Host "1. Add Migration"
    Write-Host "2. Remove Migration"
    Write-Host "3. Update Database"
    Write-Host "4. Manage User Secrets"
    Write-Host "5. Exit"
    Write-Host "====================================================="

    $choice = Read-Host "Enter your choice"
    return $choice
}

# Function to execute Entity Framework Core migration commands
function Invoke-MigrationCommands {
    param (
        [string]$option
    )

    $startupDirectory = "$PSScriptRoot/src/TaskTracker.Api/TaskTracker.Api.csproj"
    $projectDirectory = "$PSScriptRoot/src/TaskTracker.Infra/TaskTracker.Infra.csproj"

    switch ($option) {
        1 {
            $migrationName = Read-Host "Name of the migration: "
            dotnet ef migrations add $migrationName `
                --startup-project $startupDirectory `
                --project $projectDirectory `
                --verbose
        }
        2 {
            dotnet ef migrations remove `
                --startup-project $startupDirectory `
                --project $projectDirectory `
                --verbose
        }
        3 {
            dotnet ef database update `
                --startup-project $startupDirectory `
                --project $projectDirectory `
                --verbose
        }
        4 {
            Show-UserSecretsMenu
        }
        5 {
            exit
        }
        default {
            Write-Host "Invalid choice. Please select a valid option."
        }
    }
}

# Function to manage user secrets
function Show-UserSecretsMenu {
    # Add options for TaskTracker API and TaskTracker Console secrets management
    Clear-Host
    Write-Host "====================================================="
    Write-Host "User Secrets Management `n"
    Write-Host "1. TaskTracker API"
    Write-Host "2. TaskTracker Console"
    Write-Host "3. Back to Main Menu"
    Write-Host "====================================================="

    $choice = Read-Host "Enter your choice"

    switch ($choice) {
        1 {
            Manage-UserSecrets -project "./src/TaskTracker.Api"
        }
        2 {
            Manage-UserSecrets -project "./src/TaskTracker.Console"
        }
        3 {
            return
        }
        default {
            Write-Host "Invalid choice. Please select a valid option."
        }
    }
}

# Function to perform user secrets operations
function Manage-UserSecrets {
    param (
        [string]$project
    )

    Clear-Host
    Write-Host "====================================================="
    Write-Host "User Secrets Management for $project `n"
    Write-Host "1. Initialize User Secrets"
    Write-Host "2. List User Secrets"
    Write-Host "3. Set User Secret"
    Write-Host "4. Back to User Secrets Menu"
    Write-Host "====================================================="

    $choice = Read-Host "Enter your choice"

    switch ($choice) {
        1 {
            dotnet user-secrets init --project $project
            Write-Host "User secrets initialized for $project"
        }
        2 {
            dotnet user-secrets list --project $project
        }
        3 {
            $key = Read-Host "Enter the key to set"
            $value = Read-Host "Enter the value for the key"
            dotnet user-secrets set --project $project "$key" "$value"
            Write-Host "User secret set for $project"
        }
        4 {
            return
        }
        default {
            Write-Host "Invalid choice. Please select a valid option."
        }
    }
}

# Main script
while ($true) {
    $choice = Show-Menu
    Invoke-MigrationCommands $choice
    Read-Host "Press Enter to continue..."
}

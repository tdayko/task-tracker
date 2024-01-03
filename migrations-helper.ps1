# Function to display menu and get user input
function Show-Menu {
    Clear-Host
    Write-Host "====================================================="
    Write-Host "Entity Framework Core Migration Helper `n"
    Write-Host "1. Add Migration"
    Write-Host "2. Remove Migration"
    Write-Host "3. Update Database"
    Write-Host "4. Exit"
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
            exit
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
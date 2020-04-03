$address = 'https://donnermayer-azurefunctionsdemo.azurewebsites.net/api/AzureDemos.Function'

$body = ConvertTo-Json @{
    name = "Jan"
}

Invoke-WebRequest -Uri $address -Body $body
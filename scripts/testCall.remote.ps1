$address = 'https://donnermayer-azurefunctionsdemo.azurewebsites.net/api/GreeterFunction'

$body = ConvertTo-Json @{
    name = "Jan"
}

Invoke-WebRequest -Uri $address -Body $body
$address = 'http://localhost:7071/api/GreeterFunction' 

$body = ConvertTo-Json @{
    name = "Jan"
}

Invoke-WebRequest -Uri $address -Body $body
# CloudBit API Proxy

This in short is a proxy that in turn calls the CloudBit's [**Output Voltage on Device** API](http://developers.littlebitscloud.cc/#output-voltage-on-device) endpoint. The main advantage of this API is that it receives all the parameters required for the *Output voltage on device* API call such as the _Device Id_, _Access Token_, _Percent_ and _Duration_ as Query String parameters via a **GET** and then relays the information to the CloudBit API endpoint as a **POST**.

> The projects has been developed in **ASP.NET Web API** and is proudly hosted on [**AppHarbor**](https://appharbor.com/).

## Usage

### Endpoint
```http
GET https://cloudbit.apphb.com/api/trigger?deviceid=[INSERT-DEVICE-ID]&key=[INSERT-KEY]&duration=[INSERT-DURATION]&strength=[INSERT-STRENGTH]
```
Note that, actual nodes on the JSON expected by CloudBit -

```json
{ "percent": 100, "duration_ms": 3000 }
```

maps to the following Query String parameters -

```
percent     ⇒ strength
duration_ms ⇒ duration
```
## Troubleshooting Error Codes
Please refer [http://developers.littlebitscloud.cc/#errors](http://developers.littlebitscloud.cc/#errors) to know more about the errors returned by the API.

## To Dos
- [ ] Add an index.html to the live site with proper description as in the Readme.md

## License
Code is under the **MIT License**.
Documentation is under the [MIT License](https://opensource.org/licenses/MIT).

## Disclaimer
> The API comes with no warranty.

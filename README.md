# RSU B2B Sample Client - .NET Core Sample

> **IMPORTANT NOTICE**: UFST does not provide any kind of support for the code in this repository.
> This client is just one example of how a B2B web service can be accessed. The client must not be 
> perceived as a piece of production code but more as an example one can take inspiration from and can use
> to quickly get started to test whether your company can implement a successful call to one of the B2B web 
> service using the company's digital signature. UFST can not be held responsible if a company uses this client
> or parts of it in their own systems. 

> **VIGTIG MEDDELELSE**: UFST yder ikke support på kildekoden i nærværende kodebibliotek.
> Denne klient er kun et eksempel på hvordan B2B webservicene kan tilgås. Klienten skal således ikke 
> opfattes som et stykke produktionskode men mere som en eksempel man kan lade sig inspirere af og kan bruge 
> til hurtigt at komme i gang og få afprøvet om ens virksomhed kan gennemføre et succesfuldt kald til en af 
> B2B webservicene ved at bruge virksomhedens digitale signatur. UFST kan ikke stå til ansvar hvis en virksomhed
> anvender klienten eller dele af denne i deres egne systemer. 

## Build and run

First build:

```
$ dotnet build
```

Then overwrite contents of

```
$ appsettings.json
```

with the contents of `appsettings-secret.json` provided to you by UFST.

Finally, run application, e.g.:

```
$ dotnet run VirksomhedKalenderHent
```

## View certificates

Print `server.pem`:

```
$ openssl x509 -in server.pem -text
```

Print `VOCES_gyldig.p12`:

```
% openssl pkcs12 -in VOCES_gyldig.p12 -nodes -passin pass:"SECRET" | openssl x509 -noout -text
```

dotnet run --launch-profile https

https://localhost:7000/swagger/index.html

In Invoice.cs we need to define the property [Key]
[EntityType: EntitySet ‘[Entity Name]’ is based on type ‘[Entity Name]’ that has no keys defined](https://blog.taditdash.com/entitytype-entityset-entity-name-is-based-on-type-entity-name-that-has-no-keys-defined)


curl -X 'GET' \
  'https://localhost:7000/CareStationDeviceUsage/CareStationDeviceUsage(%27QUICK-Stop%27)' \
  -H 'accept: */*'
using Kestra.KestraDwDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Kestra.CareStationDeviceUsageApi.Controllers;

public class CareStationDeviceUsageController : ODataController
{
    protected readonly KestraDbContext db;
    public CareStationDeviceUsageController(KestraDbContext db)
    {
        this.db = db;
    }

    //[EnableQuery()]
    //public IActionResult GetAll()
    //{
    //    return Ok(db.Invoices);
    //}
    [EnableQuery]
    public IActionResult Get([FromRoute] string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return Ok(db.Invoices);
        }
        else
        {
            return Ok(db.Invoices.Where(i => i.ShipName == key));
        }
    }

}

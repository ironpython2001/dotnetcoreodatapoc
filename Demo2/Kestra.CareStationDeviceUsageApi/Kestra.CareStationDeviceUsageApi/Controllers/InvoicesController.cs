using Kestra.KestraDwDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Kestra.CareStationDeviceUsageApi.Controllers;

public class InvoicesController : ODataController
{
    protected readonly KestraDbContext db;
    public InvoicesController(KestraDbContext db)
    {
        this.db = db;
    }

    [EnableQuery()]
    public ActionResult<IEnumerable<Invoice>> Get()
    {
        return Ok(db.Invoices);
    }
    [EnableQuery]
    public ActionResult<Invoice> Get([FromRoute] string key)
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

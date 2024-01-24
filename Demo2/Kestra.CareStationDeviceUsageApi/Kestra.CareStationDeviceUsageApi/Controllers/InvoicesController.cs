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
        return Ok(db.Invoices.Where(i => i.ShipName == key));
    }

}

Sonradan silinen valuesController:
public class ValuesController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public ValuesController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await unitOfWork.GetReadRepository<Product>().GetAllAsync());
    }
}


using Microsoft.AspNetCore.Mvc;

namespace AACLIENTE.AAAPI.Sites.Controllers;





[ApiController]
[Route("[Controller]")]

public class SitesController : ControllerBase
{

  private static Dictionary<int, Site> sites = new Dictionary<int, Site>(){
    
        {1, new Site(){id = 1, name = "site1", userName = "Andrea", password = "123", IdCategory=3}},
        {2, new Site(){id = 2, name = "site2", userName = "Najera", password = "345", IdCategory=3}}
};
    private readonly Repository<Site> repository;
    public SitesController()
    {
        repository = new SitesRepo();
    }

    [HttpGet]
    public ActionResult<Site> Get()
    {
        return Ok(repository.getAll(

        ));
    }

    [HttpGet("{id}")]
    public ActionResult<Site> Get(int id)
    {
        
        try
        {
          Site site = repository.get(id);
         return Ok(site);
        }
        catch (System.Exception)
        {
          return NotFound("no se encuentra el sitio con id"); 
            
        }
      
    }

     [HttpPost]
    public ActionResult<Site> Post([FromBody] Site site)
    {
        
        try
        {
          repository.add(site);
          String url = Request.Path.ToString() + "/" + site.id;
          return Created(url, site);
        }
        catch (System.Exception)
        {
          return Conflict("no se encuentra el sitio con id"); 
            
        }
      
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id,[FromBody] Site site)
    {
        
        try
        {
          repository.update(id, site);   
          return Ok("Site update");
        }
        catch (System.Exception)
        {
          return NotFound("no se encuentra el sitio "); 
            
        }
    }


    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        
        try
        {
          repository.remove(id);   
          return Ok("Site removed");
        }
        catch (System.Exception)
        {
          return NotFound("no se encuentra el sitio "); 
            
        }
    }
    





}

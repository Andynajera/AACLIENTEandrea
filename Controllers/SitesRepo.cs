

namespace AACLIENTE.AAAPI.Sites.Controllers;


public interface Repository<T>{
    void add (T item);
    void remove (int id);
    void update (int id, T item);
    T get(int id);
    List<T> getAll();
}

public class SitesRepo : Repository<Site>
{
        private static Dictionary<int, Site> sites = new Dictionary<int, Site>(){
    
        {1, new Site(){id = 1, name = "test1", userName = "user", password = "password", IdCategory=3}},
        {2, new Site(){id = 2, name = "test2", userName = "user", password = "password", IdCategory=3}}
};



public void add(Site site)
{
    if(sites.ContainsKey(site.id))
    {
        throw new Exception("Site already exist");
    }
    sites.Add(site.id, site);
}

public void remove(int id)
     {
         
        if (!sites.ContainsKey(id))
        {
            throw new Exception("Site not found");
        }
        sites.Remove(id);
        
        }
public void update(int id, Site site)
    {
        if(sites.ContainsKey(id))
        {
        throw new Exception("Site not found");
        }
        sites[id] = site;
    }
    
public Site get(int id)
{
    if  (sites.ContainsKey(id))
    {
        return sites[id];
    }
    throw new Exception("Sites not found");
}

public List<Site> getAll(){ return sites.Values.ToList();}

}



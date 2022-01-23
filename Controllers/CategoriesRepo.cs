

namespace AACLIENTE.AAAPI.Categories.Controllers;

public interface Repository<T>{
    void add (T item);
    void remove (int id);
    void update (int id, T item);
    T get(int id);
    List<T> getAll();
}
public class CategoriesRepo : Category
{
      private static Dictionary<int, Category> categories = new Dictionary<int, Category>(){};
    
public void add(Category category)
{
   
    
    if(categories.Count==0){
        category.id=1;
    }
    else{
    category.id=categories.Keys.Max()+1;
    }
    categories.Add(category.id ,category);

 }

    
   


public void remove(int id)
     {
         
        if (!categories.ContainsKey(id))
        {
            throw new Exception("Category not found");
        }
        categories.Remove(id);
        
        }
public void update(int id, Category category)
    {
        if(!categories.ContainsKey(id))
        {
        throw new Exception("Category not found");
        }
        categories[id] = category;
    }
    
public Category get(int id)
{
    if  (categories.ContainsKey(id))
    {
        return categories[id];
    }
    throw new Exception("Category not found");
}

public List<Category> getAll(){ return categories.Values.ToList();}

}


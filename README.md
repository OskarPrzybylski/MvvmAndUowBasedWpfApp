# MvvmAndUowBasedWpfApp
## Short description
Wpf application based on MVVM and Unit Of Work pattern. MahApps.Metro([link](https://github.com/MahApps/MahApps.Metro)) added to project in case of modern UI.
## How to add new entity?
1. Just add entity class in Entities folder.

~~~~
public class YourEntity : DbEntity{

//your properites

}
~~~~

2. Create repository for your entity.

~~~~
public class YourEntitiesRepository : GenericRepository<YourEntity>{

//Add here your methods

}
~~~~

3. Add DbSet in DatabaseContext.cs.

~~~~
DbSet<YourEntity> yourentities {get; set;}
~~~~

4. Add repository field and property in UnitOfWork.cs.

~~~~
public YourEntitiesRepository YourEntitiesRepository
        {
            get
            {
                if (this._yourEntitiesRepository == null)
                {
                    this._yourEntitiesRepository = new YourEntitiesRepository(_databaseContext);
                }

                return _yourEntitiesRepository;
            }
        }
~~~~

5. Done! :)

## How to add new View? (comming soon)
## How to use binding in this project? (comming soon)
## How to create commands in this project? (comming soon)

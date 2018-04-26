using Minor.GenericCRUD.Models;
using Minor.GenericCRUD.Services;

namespace Minor.GenericCRUD.Controllers
{
    public class StudentsController : CrudController<Student,CrudService<Student>>
    {
    }   

}
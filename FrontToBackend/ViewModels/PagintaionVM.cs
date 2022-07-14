using System.Collections.Generic;

namespace FrontToBackend.ViewModels
{
    public class PagintaionVM<T>
    {
        public List<T> Items  { get; set; }
        public int PageCount{ get; set; }
        public int CurrentPage{ get; set; }
        public PagintaionVM(List<T> items ,int pageCount,int currentPage )

        {
            Items = items;
            PageCount = pageCount;
            CurrentPage = currentPage;

        }
    }
}

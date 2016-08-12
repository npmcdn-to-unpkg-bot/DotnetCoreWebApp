using Core.Common.Extensions;

namespace WebApplication.ViewModels
{
    public abstract class BaseViewModel
    {
        public string SearchTerms { get; set; }
        public string SortColumn { get; set; }

        public string SortDirection { get; set; }
        public bool SearchTermsExist { get{return !SearchTerms.IsNullOrWhiteSpace();} private set{} }

        public void ClearSearchTerms()
        {
            SearchTerms = string.Empty;
        }
    }
}
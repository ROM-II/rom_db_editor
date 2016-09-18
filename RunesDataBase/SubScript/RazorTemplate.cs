using RazorEngine.Templating;

namespace RunesDataBase.SubScript
{
    public class RazorTemplate<T> : TemplateBase<T>
    {
        public new T Model
        {
            get { return base.Model; }
            set { base.Model = value; }
        }

        public RazorTemplate()
        {
        }
    }
}
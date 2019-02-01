namespace BreakPoint.Services
{
    using BreakPoint.Data;

    public abstract class Service
    {
        public Service(BreakPointDBContext context)
        {
            this.Context = context;
        }

        protected BreakPointDBContext Context { get; set; }
    }
}
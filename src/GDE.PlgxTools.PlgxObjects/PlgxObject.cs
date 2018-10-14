namespace GDE.PlgxTools.RawPlgxObjects
{
    public abstract class PlgxObject
    {
        protected string GetPlgxObjectName()
        {
            string objectName = this.GetType().Name;
            return objectName.Substring(0, objectName.Length - "PlgxObject".Length);
        }

        public override string ToString()
        {
            return this.GetPlgxObjectName();
        }
    }
}

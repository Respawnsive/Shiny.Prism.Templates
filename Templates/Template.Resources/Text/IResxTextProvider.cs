namespace Template.Resources.Text
{
    /// <summary>
    /// Resx text provider
    /// </summary>
    /// <typeparam name="T">Should be a Resx Designer class with a ResourceManager property</typeparam>
    public interface IResxTextProvider<T> : ITextProvider where T : class
    {
    }
}

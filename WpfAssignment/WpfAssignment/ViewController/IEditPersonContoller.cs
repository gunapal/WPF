namespace WpfAssignment.ViewController
{
    using WpfAssignment.Datamodel;

    /// <summary>
    /// Interface to be implemented by an Edit screen.
    /// </summary>
    public interface IEditPersonContoller
    {
        Person EditPerson(Person personToEdit);
    }
}

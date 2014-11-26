// -----------------------------------------------------------------------
// <copyright file="ViewCokntroller.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace WpfAssignment.ViewController
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WpfAssignment.View;
    using WpfAssignment.Datamodel;

    /// <summary>
    /// Controller to invoke the appropriate edit screen.
    /// </summary>
    public class EditViewController : IEditPersonContoller 
    {
        public Person EditPerson(Person personToEdit)
        {
            EditPersonWindow epw = new EditPersonWindow(personToEdit);
            epw.ShowDialog();
            return personToEdit;
        }
    }
}

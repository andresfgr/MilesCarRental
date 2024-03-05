namespace MilesCarRental.Interfaces
{
    /// <summary>
    /// Interfaz para la gestión de usuarios.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Obtiene el nombre del usuario actual.
        /// </summary>
        /// <returns>El nombre del usuario actual.</returns>
        string GetMyName();
    }
}


using Control_Transacciones_BD3.Models;

class Program
{
    static void Main(string[] args)
    {
        agregarPersonaTransaction();
        //eliminarPersonaTransaction();
    }

    //Agregar Persona
    public static void agregarPersonaTransaction()
    {
        Console.WriteLine("Metodo agregar persona haciendo uso del control de transacciones");
        ModeloDatos2Context context = new ModeloDatos2Context();

        GeneroMusical stdMusica = new GeneroMusical();
        Nacionalidad stdNacionalidad = new Nacionalidad();
        Persona stdPersona = new Persona();

        var dbContextTransaction = context.Database.BeginTransaction();

        try
        {
            //Añade a la tabla Música
            stdMusica.NombreGeneroMusical = "Rock";
            stdMusica.FechaRegistro = Convert.ToDateTime("2023-07-04");
            stdMusica.Estado = "Activo";
            context.GeneroMusicals.Add(stdMusica);
            context.SaveChanges();

            //Añade a la tabla Nacionalidad
            stdNacionalidad.NombreNacionalidad = "España";
            stdNacionalidad.FechaRegistro = Convert.ToDateTime("2023-07-04");
            stdNacionalidad.Estado = "Activo";
            context.Nacionalidads.Add(stdNacionalidad);
            context.SaveChanges();

            //Añade a la tabla Persona
            stdPersona.Nombres = "Andrea";
            stdPersona.Apellidos = "Nova";
            stdPersona.Telefono = "0999999999";
            stdPersona.FechaNacimiento = Convert.ToDateTime("1995-07-04");
            stdPersona.Estado = "Activo";
            stdPersona.IdGeneroMusical = stdMusica.Id;
            stdPersona.IdNacionalidad = stdNacionalidad.Id;
            context.Personas.Add(stdPersona);
            context.SaveChanges();


            if (string.IsNullOrEmpty(stdPersona.Nombres) || stdPersona.Apellidos == null || stdPersona.Telefono == null)
            {
                Console.WriteLine("Ha ingresado uno o más campos vacíos. Rollback ejecutado.");
                dbContextTransaction.Rollback();
            }
            else
            {
                dbContextTransaction.Commit();
                Console.WriteLine("Datos agregados exitosamente");
            }


            dbContextTransaction.Commit();
            Console.WriteLine("Datos guardados con exito");
        }
        catch (Exception e)
        {
            dbContextTransaction.Rollback();
            Console.WriteLine("Error " + e.ToString());
        }
    }
}
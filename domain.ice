

// https://doc.zeroc.com/ice/3.7/language-mappings/java-mapping/client-side-slice-to-java-mapping/customizing-the-java-mapping
["java:package:cl.ucn.disc.pdis.fivet.zeroice", "cs:namespace:Fivet.ZeroIce"]
module model {

    /**
     * The base system.
     */
     interface TheSystem {

        /**
         * @return the diference in time between client and server.
         */
        long getDelay(long clientTime);

     }

     /**
     * Persona
     */
     class Persona{

        // PK
        long id;
        // Rut
        string rut;
        // Nombre
        string nombre;
        // address
        string direccion;
        // Telefono
        long telefono;
        // Número télefono celular
        long celular;
        // email
        string email;

     }

     /**
     *  Ficha de paciente
     */
     class Ficha {

         // Id
         int id;
         // Numero de registro
         int numero;
         // name
         string nombre;
         // Especie
         string especie;
         // Fecha de nacimiento
         string fechaNacimiento;
         // Raza
         string raza;
         // Sexo
         string sexo;
         // Color
         string color;
         // Tipo
         string tipo;

     }
     /**
     * Clase Control
     */
     class Control{

        // Fecha
        string fechaControl;
        // Fecha proximo control
        string fechaProximoControl;
        // Temperatura
        double temperatura;
        // Peso
        double peso;
        // Altura
        double altura;
        // Diagnostico
        string diagnostico;
        // Veterinario TODO: Veterinario es persona?
        string veterinario;


     }


}

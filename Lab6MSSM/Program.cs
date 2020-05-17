using System;
using System.Runtime.Serialization;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace Lab6MSSM
{
    class Program
    {

        //Metodo para serializar una empresa.
        public static void guardarEmpresa(Empresa empGuardar, string fileName)
        {

            Stream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(fs, empGuardar);
            fs.Close();
        }

        //Metodo para deserializar una empresa.
        public static Empresa cargarEmpresa(string fileName)
        {

            FileStream fs = new FileStream(fileName, FileMode.Open);
            IFormatter formatter = new BinaryFormatter();
            Empresa empresaAbierta = formatter.Deserialize(fs) as Empresa;
            fs.Close();
            return empresaAbierta;

        }

        //Func. que me permite crear una empresa manualmente. 

        public static Empresa creadorEmpresa()
        {
            Console.WriteLine("Ingrese nombre de empresa: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Ingrese RUT de empresa: ");
            int newRut = Convert.ToInt32(Console.ReadLine());

            // Creo nueva empresa y retorno. 

            Empresa newCompany = new Empresa(newName, newRut);
            return newCompany;
        }


        public static Persona crearEmpleado()
        {
            Console.WriteLine("Ingrese nombre empleado: ");
            string name = Console.ReadLine();

            Console.WriteLine("Ingrese RUT empleado: ");
            int rut = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese cargo empleado: ");
            string cargo = Console.ReadLine();

            Persona employee = new Persona(name, rut, cargo);
            return employee;
        }



        //MAIN. 
        static void Main(string[] args)
        {
            bool runMain = true;

            while (runMain)
            {
                Console.Clear();
                Console.WriteLine("1. Ejecutar Funcionalidades Item 1 Enunciado: ");
                Console.WriteLine("2. Ejecutar Funcionalidades Item 2 Enunciado: ");
                Console.WriteLine("3. Ejecutar Funcionalidades Item 3 Enunciado: ");
                Console.WriteLine("4. Ejecutar Funcionalidades Item 4 Enunciado: ");
                Console.WriteLine("5. Salir: ");
                Console.WriteLine("Ingrese opcion: ");


                int menuChoice = Convert.ToInt32(Console.ReadLine());

                switch (menuChoice)
                {

                    //CODIGO ITEM 1 ENUNCIADO.

                    case 1:
                        Console.Clear();

                        Console.WriteLine("¿Desea abrir info. empresa desde archivo?");
                        Console.WriteLine("1. Si: ");
                        Console.WriteLine("2. No: ");
                        Console.WriteLine("3. Volver a menu principal: ");

                        int firstChoice = Convert.ToInt32(Console.ReadLine());

                        switch (firstChoice)
                        {

                            //Intento abrir archivo empresa.bin.
                            //Si no existe, lo creo y lo guardo. 

                            case 1:
                                try
                                {
                                    Empresa loadedCompany = cargarEmpresa("empresa.bin");
                                    Console.WriteLine("Nombre Empresa en Archivo: "); Console.WriteLine(loadedCompany.nombre);
                                    Console.WriteLine("RUT Empresa en Archivo: "); Console.WriteLine(loadedCompany.rut);
                                    Thread.Sleep(5000);
                                    break;
                                }
                                catch (FileNotFoundException)
                                {
                                    Console.WriteLine("No existe archivo de empresa.");
                                    //Creo nueva empresa manualmente. 
                                    Empresa newEmpresaE = creadorEmpresa();

                                    //La guardo. 

                                    try
                                    {
                                        guardarEmpresa(newEmpresaE, "empresa.bin");
                                        Console.WriteLine("Empresa creada con exito.");
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("No se pudo crear empresa.");
                                        throw;
                                    }


                                    Thread.Sleep(2500); break;
                                    throw;
                                }


                            case 2:
                                // Creo nueva empresa manualmente.
                                Empresa newCompany = creadorEmpresa();

                                //Guardo en archivo .bin. 
                                try
                                {
                                    guardarEmpresa(newCompany, "empresa.bin");
                                    Console.WriteLine("Empresa guardada con exito.");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("No se pudo guardar empresa.");
                                    throw;
                                }
                                Thread.Sleep(2500); Console.Clear();
                                break;
                            case 3:
                                break;
                        }
                        break;


                    //CODIGO ITEM 2 ENUNCIADO.

                    case 2:


                        //Primero creo los encargados de las divisiones. 

                        Persona Enc1 = new Persona("Rosa Perez", 12351, "Encargada");
                        Persona Enc2 = new Persona("Juanito Lopez", 23213, "Encargado");
                        Persona Enc3 = new Persona("Martina Perez", 31241, "Encargada");


                        //Creo algunas divisiones y les asigno un encargado a cada una. 

                        Division marketing = new Division("Marketing", Enc1);
                        Division finanzas = new Division("Finanzas", Enc2);
                        Division operaciones = new Division("Operaciones", Enc3);

                        //Voy a abrir la empresa, modificarla agregando las divisiones vacias y guardarla. 

                        try
                        {
                            Empresa theCompany = cargarEmpresa("empresa.bin"); Console.Clear();
                            Console.WriteLine("Empresa cargada con exito."); 
                            Console.WriteLine("\n");
                            Console.WriteLine("Nombre Empresa en Archivo: "); Console.WriteLine(theCompany.nombre);
                            Console.WriteLine("RUT Empresa en Archivo: "); Console.WriteLine(theCompany.rut);


              
                            //Agrego divisiones a lista de divisiones de mi empresa.

                            theCompany.listaDivisiones.Add(marketing); theCompany.listaDivisiones.Add(finanzas);
                            theCompany.listaDivisiones.Add(operaciones);

                            //Serializo empresa actualizada. 

                            try
                            {
                                guardarEmpresa(theCompany, "empresa.bin");
                                Console.WriteLine("Se agregaron divisiones con exito.");

                                Console.WriteLine("\n");

                                Console.WriteLine("Lista de divisiones actual:");

                                for (int i = 0; i < theCompany.listaDivisiones.Count(); i++)
                                {
                                    string stream = Convert.ToString(i) + " " + theCompany.listaDivisiones[i].nombre;
                                    Console.WriteLine(stream);
                                }

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se pudo agregar divisiones a empresa.");
                                throw;
                            }

                            Thread.Sleep(5000);
                            break;
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("No existe archivo de empresa. Se puede crear empleando funcionalidades del item 1.");
                            Thread.Sleep(5000);

                            break;

                        }


                    //CODIGO ITEM 3 ENUNCIADO.

                    case 3:

                        //Creo algunos empleados.

                        Persona juan = new Persona("Juan Perez", 12345, "Jefe");
                        Persona pedro = new Persona("Pedro Lopez", 44123, "Empleado");
                        Persona fran = new Persona("Fran Perez", 11512, "Analista");
                        Persona tomas = new Persona("Tomas Lopez", 85851, "Empleado");
                        Persona manuel = new Persona("Manuel Serra", 14544, "Gerente");


                        //Abro empresa y asigno estos empleados a los departamentos que corresponden. 


                        try
                        {
                            //Cargo empresa.

                            Empresa theCompany = cargarEmpresa("empresa.bin"); Console.Clear();
                            Console.WriteLine("Empresa cargada con exito.");
                            Console.WriteLine("\n");
                            Console.WriteLine("Nombre Empresa en Archivo: "); Console.WriteLine(theCompany.nombre);
                            Console.WriteLine("RUT Empresa en Archivo: "); Console.WriteLine(theCompany.rut);

                            //Para probar las funcionalidades pedidas en el item 3, voy a crear nuevos empleados, encargados y departamentos, 
                            //los voy a incorporar a la empresa abierta y voy a actualizar el archivo modificado. 

                            //Creo mas encargados. 

                            Persona enc5 = new Persona("Rosa Perez", 51851, "Encargada");
                            Persona enc6 = new Persona("Juanita Perez", 134212, "Encargada");
                            Persona enc7 = new Persona("Rosario Perez", 451424, "Encargada");
                            Persona enc8 = new Persona("Marco Lopez", 51233, "Encargado");


                            //Creo otro par de divisiones y les asigno encargados y empleados. 

                            Division ventas = new Division("Ventas", enc5);
                            Division gerencia = new Division("Gerencia", enc6);

                            //Creo un par de bloques y les asigno empleados. 

                            Bloque corporativo = new Bloque("Corporativo", enc7);
                            Bloque recHumanos = new Bloque("Recursos Humanos", enc8);


                            corporativo.personalDiv.Add(juan); recHumanos.personalDiv.Add(pedro); recHumanos.personalDiv.Add(fran);
                            corporativo.personalDiv.Add(tomas); recHumanos.personalDiv.Add(manuel);


                            theCompany.listaDivisiones.Add(corporativo); theCompany.listaDivisiones.Add(recHumanos);

                            //Guardo empresa actualizada con divisiones nuevas y empleados en archivo .bin correspondiente. 
                            try
                            {
                                guardarEmpresa(theCompany, "empresa.bin");
                                Console.WriteLine("Empresa actualizada guardada con exito.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se pudo guardar empresa.");
                                throw;
                            }
                            Thread.Sleep(5000); Console.Clear();
                            break;

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No se pudo realizar operacion. Checkear si empresa fue creada, si no ha sido creada crear empleando metodos en item 1.");
                            throw;
                        }


                    //CODIGO ITEM 4 ENUNCIADO.

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Output main 'Actualizado':");
                        Console.WriteLine("OJO: Al correr item 3, agrego empleados a cada seccion, por lo que si no se corre antes, output sera erroneo.");


                        //Intento abrir archivo. Si funciona, muestro datos. 

                        try
                        {
                            Empresa laEmpresa = cargarEmpresa("empresa.bin");
                            Console.WriteLine("Nombre Empresa en Archivo: "); Console.WriteLine(laEmpresa.nombre);
                            Console.WriteLine("RUT Empresa en Archivo: "); Console.WriteLine(laEmpresa.rut);
                            Thread.Sleep(1000);

                            //Muestro divisiones: 

                            Console.WriteLine("Lista de divisiones:");

                            for (int i = 0; i < laEmpresa.listaDivisiones.Count(); i++)
                            {
                                string data1 = Convert.ToString(i) + " " + laEmpresa.listaDivisiones[i].nombre;
                                Console.WriteLine(data1);

                                //Muestro encargado:

                                string data2 = "Encargado :" + laEmpresa.listaDivisiones[i].encargado.nombre;
                                Console.WriteLine(data2);

                                //Si tengo empleados, los muestro. 

                                if (laEmpresa.listaDivisiones[i].personalDiv != null)
                                {
                                    Console.WriteLine("Empleados seccion:");
                                    for (int k = 0; k < laEmpresa.listaDivisiones[i].personalDiv.Count(); k++)
                                    {
                                        string empData = Convert.ToString(k) +". " + laEmpresa.listaDivisiones[i].personalDiv[k].nombre;
                                        Console.WriteLine(empData);
                                    }
                                }

                                Console.WriteLine("\n");

                            }

                            Thread.Sleep(7500);

                            break;
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("No existe archivo de empresa.");
                            //Creo nueva empresa manualmente. 
                            Empresa newEmpresaD = creadorEmpresa();

                            //Crear departamento junto con encargado y 2 empleados. 

                            Console.WriteLine("Ingrese nombre de departamento: "); string nombreDep = Console.ReadLine();
                            Console.WriteLine("Ingrese nombre de encargado: "); string nombreEnc1 = Console.ReadLine();
                            Console.WriteLine("Ingrese RUT de encargado: "); int rutEnc1 = Convert.ToInt32(Console.ReadLine());

                            Persona encNew1 = new Persona(nombreEnc1, rutEnc1, "Encargado");
                            Departamento newDep1 = new Departamento(nombreDep, encNew1);

                            Persona empleado1 = crearEmpleado();
                            Persona empleado2 = crearEmpleado();

                            newDep1.personalDiv.Add(empleado1); newDep1.personalDiv.Add(empleado2);
                            newEmpresaD.listaDivisiones.Add(newDep1);

                            Console.Clear();


                            //Crear seccion junto con encargado y 2 empleados. 

                            Console.WriteLine("Ingrese nombre de seccion: "); string nombreSec = Console.ReadLine();
                            Console.WriteLine("Ingrese nombre de encargado: "); string nombreEnc2 = Console.ReadLine();
                            Console.WriteLine("Ingrese RUT de encargado: "); int rutEnc2 = Convert.ToInt32(Console.ReadLine());

                            Persona encNew2 = new Persona(nombreEnc2, rutEnc2, "Encargado");
                            Seccion newSec1 = new Seccion(nombreSec, encNew2);

                            Persona empleado3 = crearEmpleado();
                            Persona empleado4 = crearEmpleado();

                            newSec1.personalDiv.Add(empleado3); newSec1.personalDiv.Add(empleado4);
                            newEmpresaD.listaDivisiones.Add(newSec1);

                            Console.Clear();

                            //Crear bloque 1.

                            Console.WriteLine("Ingrese nombre de bloque: "); string nombreBloc1 = Console.ReadLine();
                            Console.WriteLine("Ingrese nombre de encargado: "); string nombreEnc3 = Console.ReadLine();
                            Console.WriteLine("Ingrese RUT de encargado: "); int rutEnc3 = Convert.ToInt32(Console.ReadLine());

                            Persona encNew3 = new Persona(nombreEnc3, rutEnc3, "Encargado");
                            Seccion newBloc1 = new Seccion(nombreBloc1, encNew3);

                            Persona empleado5 = crearEmpleado();
                            Persona empleado6 = crearEmpleado();

                            newBloc1.personalDiv.Add(empleado5); newBloc1.personalDiv.Add(empleado6);
                            newEmpresaD.listaDivisiones.Add(newBloc1);


                            //Crear bloque 2. 


                            Console.WriteLine("Ingrese nombre de bloque: "); string nombreBloc2 = Console.ReadLine();
                            Console.WriteLine("Ingrese nombre de encargado: "); string nombreEnc4 = Console.ReadLine();
                            Console.WriteLine("Ingrese RUT de encargado: "); int rutEnc4 = Convert.ToInt32(Console.ReadLine());

                            Persona encNew4 = new Persona(nombreEnc4, rutEnc4, "Encargado");
                            Seccion newBloc2 = new Seccion(nombreBloc2, encNew4);

                            Persona empleado7 = crearEmpleado();
                            Persona empleado8 = crearEmpleado();

                            newBloc2.personalDiv.Add(empleado7); newBloc2.personalDiv.Add(empleado8);
                            newEmpresaD.listaDivisiones.Add(newBloc2);

                            //La guardo.
                            try
                            {
                                guardarEmpresa(newEmpresaD, "empresa.bin");
                                Console.WriteLine("Empresa guardada con exito.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("No se pudo crear empresa.");
                                throw;
                            }


                            Thread.Sleep(2500); break;
                            throw;
                        }


                            
                }



            }
        }
    }
}

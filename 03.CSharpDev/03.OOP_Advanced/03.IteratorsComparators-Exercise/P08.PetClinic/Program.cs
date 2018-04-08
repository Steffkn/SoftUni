namespace P08.PetClinic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using P08.PetClinic.Models;

    public class Program
    {
        public static void Main()
        {
            var clinics = new List<Clinic>();
            var pets = new List<Pet>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            string itemToCreate = commandArgs[1];
                            string name = commandArgs[2];

                            if (itemToCreate.Equals("Pet"))
                            {
                                int age = int.Parse(commandArgs[3]);
                                string kind = commandArgs[4];

                                Pet newPet = new Pet(name, age, kind);
                                pets.Add(newPet);
                            }
                            else
                            {
                                int roomsCount = int.Parse(commandArgs[3]);

                                Clinic clinicToAdd = new Clinic(name, roomsCount);
                                clinics.Add(clinicToAdd);
                            }
                            break;
                        case "Add":
                            string newPetName = commandArgs[1];
                            string addClinicName = commandArgs[2];

                            Pet accomodatePet = pets.FirstOrDefault(x => x.Name == newPetName);
                            Clinic accomodateClinic = clinics.FirstOrDefault(x => x.Name == addClinicName);

                            bool isAccomodateSuccess = accomodateClinic.Accomodate(accomodatePet);

                            Console.WriteLine(isAccomodateSuccess);
                            break;
                        case "Release":
                            string releaseAnimalClinic = commandArgs[1];
                            Clinic releaseClinic = clinics.FirstOrDefault(x => x.Name == releaseAnimalClinic);
                            bool isAnimalReleased = releaseClinic.Release();

                            Console.WriteLine(isAnimalReleased);
                            break;
                        case "HasEmptyRooms":
                            string hasClinicEmptyRooms = commandArgs[1];
                            Clinic freeRoomClinic = clinics.FirstOrDefault(x => x.Name == hasClinicEmptyRooms);

                            bool hasEmptyRooms = freeRoomClinic.HasEmptyRooms();

                            Console.WriteLine(hasEmptyRooms);
                            break;
                        case "Print":
                            string printClinicName = commandArgs[1];
                            Clinic printClinic = clinics.FirstOrDefault(x => x.Name == printClinicName);

                            if (commandArgs.Length == 2)
                            {
                                printClinic.Print();
                            }
                            else
                            {
                                int roomNumber = int.Parse(commandArgs[2]);
                                printClinic.Print(roomNumber);
                            }
                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

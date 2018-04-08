namespace P08.PetClinic.Models
{
    public class Room
    {
        private Pet pet;

        public Room()
        {
        }

        public void AddPet(Pet givenPet)
        {
            this.pet = givenPet;
        }

        public void RemovePet()
        {
            this.pet = null;
        }

        public bool IsEmpty => this.pet == null;

        public override string ToString()
        {
            if (this.pet != null)
            {
                return pet.ToString();
            }

            return "Room empty";
        }
    }
}

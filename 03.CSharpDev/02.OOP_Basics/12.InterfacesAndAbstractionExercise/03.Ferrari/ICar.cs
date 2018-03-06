public interface ICar
{
    string Driver { get; set; }

    string Model { get; set; }

    string UseBreaks();

    string UseGasPedal();
}
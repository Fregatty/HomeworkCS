using System;
using System.IO;
using System.Xml.Serialization;

// Вариант B1
namespace Homework
{
    public enum LocoType
    {
        Electro,
        Thermal
    }
    public enum CarriageType
    {
        Cargo,
        Passenger
    }
    public class Carriage
    {
        public string Model { get; set; }
        public int SerialNum { get; set; }
        public CarriageType CarriageType { get; set; }
        public int SeatsNum { get; set; }
        public int Capacity { get; set; }

        public Carriage() { }
        public Carriage (string model, int serialNum, CarriageType carriageType, int seatsNum, int capacity)
        {
            Model = model;
            SerialNum = serialNum;
            CarriageType = carriageType;
            SeatsNum = seatsNum;
            Capacity = capacity;
        }
    }

    public class Locomotive
    {
        public string Model { get; set; }
        public int SerialNum { get; set; }
        public LocoType LocoType { get; set; }
        public Locomotive() { }
        public Locomotive(string model, int serialNum, LocoType locoType)
        {
            Model = model;
            SerialNum = serialNum;
            LocoType = locoType;
        }
    }

    [Serializable]
    public class Train
    {
        public int TrainNum { get; set; }
        public Locomotive Loco { get; set; }
        public Carriage[] Carriages { get; set; }

        public Train() { }
        public Train(int trainNum, Locomotive loco, Carriage[] carriages)
        {
            TrainNum = trainNum;
            Loco = loco;
            Carriages = carriages;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Carriage[] carriages = new Carriage[3];
            carriages[0] = new Carriage("model1", 15, CarriageType.Cargo, 0, 5000);
            carriages[1] = new Carriage("model2", 24, CarriageType.Passenger, 250, 1000);
            carriages[2] = new Carriage("model3", 63, CarriageType.Passenger, 500, 2000);

            Locomotive loco = new Locomotive("loco1", 115, LocoType.Thermal);

            Train train = new Train(1, loco, carriages);        
            
            XmlSerializer formatter = new XmlSerializer(typeof(Train));
            using (FileStream fs = new FileStream(@"train.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, train);
            }
        }
    }
}

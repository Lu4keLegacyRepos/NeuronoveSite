using Perceptron.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Perceptron.DataSet
{
    public class DataLoader
    {

        public string Path { get; set; }
        public (double from, double to) Range { get;private set; }
        public DataLoader(string path)
        {
            Path = path;
        }

        public (List<IDataSet> trainData, List<IDataSet> testData) GetDataSets()
        {
            var serializer = new XmlSerializer(typeof(perceptronTask));
            using StreamReader reader = new StreamReader(Path);
            var tmp = (perceptronTask)serializer.Deserialize(reader);

            var trainData = tmp.TrainSet.Select(x =>  new TrainingSet() { Input = x.inputs, Output = x.output }).ToList<IDataSet>();

            var testData = tmp.TestSet.Select(x => new TestSet() { Input = x.inputs }).ToList<IDataSet>();

            Range = (tmp.perceptron.inputDescriptions[0].minimum, tmp.perceptron.inputDescriptions[0].maximum);
            return (trainData, testData);
        }


    }
}

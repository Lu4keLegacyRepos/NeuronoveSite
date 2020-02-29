namespace Perceptron
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class perceptronTask
    {

        private perceptronTaskPerceptron perceptronField;

        private perceptronTaskElement[] testSetField;

        private perceptronTaskElement2[] trainSetField;

        /// <remarks/>
        public perceptronTaskPerceptron perceptron
        {
            get
            {
                return this.perceptronField;
            }
            set
            {
                this.perceptronField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("element", IsNullable = false)]
        public perceptronTaskElement[] TestSet
        {
            get
            {
                return this.testSetField;
            }
            set
            {
                this.testSetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("element", IsNullable = false)]
        public perceptronTaskElement2[] TrainSet
        {
            get
            {
                return this.trainSetField;
            }
            set
            {
                this.trainSetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class perceptronTaskPerceptron
    {

        private perceptronTaskPerceptronInputDescriptions[] inputDescriptionsField;

        private double lerningRateField;

        private string nameField;

        private double[] weightsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("inputDescriptions")]
        public perceptronTaskPerceptronInputDescriptions[] inputDescriptions
        {
            get
            {
                return this.inputDescriptionsField;
            }
            set
            {
                this.inputDescriptionsField = value;
            }
        }

        /// <remarks/>
        public double lerningRate
        {
            get
            {
                return this.lerningRateField;
            }
            set
            {
                this.lerningRateField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("weight", IsNullable = false)]
        public double[] weights
        {
            get
            {
                return this.weightsField;
            }
            set
            {
                this.weightsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class perceptronTaskPerceptronInputDescriptions
    {

        private double maximumField;

        private double minimumField;

        private string nameField;

        /// <remarks/>
        public double maximum
        {
            get
            {
                return this.maximumField;
            }
            set
            {
                this.maximumField = value;
            }
        }

        /// <remarks/>
        public double minimum
        {
            get
            {
                return this.minimumField;
            }
            set
            {
                this.minimumField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class perceptronTaskElement
    {

        private double[] inputsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public double[] inputs
        {
            get
            {
                return this.inputsField;
            }
            set
            {
                this.inputsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class perceptronTaskElement2
    {

        private double[] inputsField;

        private double outputField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public double[] inputs
        {
            get
            {
                return this.inputsField;
            }
            set
            {
                this.inputsField = value;
            }
        }

        /// <remarks/>
        public double output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
            }
        }
    }


}

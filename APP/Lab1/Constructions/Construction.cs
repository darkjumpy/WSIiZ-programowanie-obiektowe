using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.Abstract;
using Lab1.Constructions.Models;
using Lab1.Interfaces;
using Lab1.Materials;

namespace Lab1.Constructions
{
    internal class Construction : ISquareCost, IConstructionInfo
    {
        public Construction(float height, float width, int entrances, int humanCapacity, TypeOfMaterial buildMaterial)
        {
            Height = height;
            Width = width;
            Entrances = entrances;
            HumanCapacity = humanCapacity;
            BuildMaterial = buildMaterial;
        }

        public Construction(CreateConstructionDto constructionDto)
        {
            Height = constructionDto.Height;
            Width = constructionDto.Width;
            Entrances = constructionDto.Entrances;
            HumanCapacity = constructionDto.HumanCapacity;
            BuildMaterial = constructionDto.BuildMaterial;
        }

        public Construction()
        {
            Height = 100;
            Width = 100;
            Entrances = 3;
            HumanCapacity = 20;
            BuildMaterial = TypeOfMaterial.Concrete;
        }

        private TypeOfMaterial _buildMaterial { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public int Entrances { get; set; }
        public int HumanCapacity { get; set; }
        private AbstractMaterial? _material { get; set; }

        private void InitializeMaterial()
        {
            switch (_buildMaterial)
            {
                case TypeOfMaterial.Brick:
                    _material = new BrickMaterial();
                    break;
                case TypeOfMaterial.Concrete:
                    _material = new ConcreteMaterial();
                    break;
                case TypeOfMaterial.Wood:
                    _material = new WoodMaterial();
                    break;
                default:
                    _material = new BrickMaterial();
                    break;
            }
        }

        public double GetSquareCost()
        {
            InitializeMaterial();
            return Width * Height * 0.9 * _material.CalculateMaterialCost();
        }
        public TypeOfMaterial BuildMaterial
        {
            get
            {
                return _buildMaterial;
            }
            set
            {
                _buildMaterial = value;
            }
        }

        public double CalculateSquareCost()
        {
            double squareArea = Height * Width;
            double costPerSquareUnit = 10.0; 
            return squareArea * costPerSquareUnit;
        }

        public void DisplayCostDetails()
        {
            throw new NotImplementedException();
        }

        public void DisplayConstructionInfo()
        {
            Console.WriteLine($"Construction information for the building:");
            Console.WriteLine($"Height: {Height}, Width: {Width}, Entrances: {Entrances}, Human Capacity: {HumanCapacity}, Build Material: {BuildMaterial}");
        }
    }
}

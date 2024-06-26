﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ShoeShineAPI.Enum;

namespace ShoeShineAPI.Core.RequestModel
{
    public class StoreRequest
    {
        [JsonIgnore]
        public int StoreId { get; set; }// Primary Key
        
        [Required(ErrorMessage = "StoreName is required.")]
        [StringLength(100, ErrorMessage = "StoreName must not exceed 100 characters.")]
        public string StoreName { get; set; } = string.Empty;

        [Required(ErrorMessage = "StoreAddress is required.")]
        [StringLength(200, ErrorMessage = "StoreAddress must not exceed 200 characters.")]
        public string StoreAddress { get; set; } = string.Empty;
        [JsonIgnore]
        public string StoreDescription { get; set; } = "Description Is Empty!";
        [Required(ErrorMessage = "StorePhone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "StorePhone must be 10 digits.")]
        public string StorePhone { get; set; } = string.Empty;

        [Required(ErrorMessage = "StoreEmail is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string StoreEmal { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsStoreStatus { get; set; } = true;
        [JsonIgnore]
        [Required(ErrorMessage = "Url is required.")]
        [StringLength(150, ErrorMessage = "Url must not exceed 150 characters.")]
        public string Url { get; set; } = "Link Image Empty!";
        [JsonIgnore]
        [Required(ErrorMessage = "ServiceArray is required.")]
        //[Range(1,10,ErrorMessage =("Type Int 1-10"))]
        public int[] ServiceArray { get; set; } = new int[1]{1};
        [JsonIgnore]
        [Required(ErrorMessage = "CategoryArray is required.")]
        public int[] CategoryArray { get; set; } = new int[1] {1};
        [JsonIgnore]
        [Required(ErrorMessage = "CategoryArray is required.")]
        public float[] ServicePrice { get; set; } = new float[1] { 50000 };
        //Foreign Key
        [JsonIgnore]
        public int RatingId { get; set; } = (int)EnumClass.RatingEnum.One_Star;
    }
}

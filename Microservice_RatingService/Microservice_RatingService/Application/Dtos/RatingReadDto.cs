﻿using Microservice_RatingService.Domain.Enums;

namespace Microservice_RatingService.Application.Dtos
{
    public class RatingReadDto
    {
        public Guid RatingId { get; set; }
        public DateTime RatingDate { get; set; }
        public int Grade { get; set; }
        public string? Comment { get; set; }
        public string? Title { get; set; }
        public Status Status { get; set; }
        public Guid BuyerId { get; set; }
        public Guid SellerId { get; set; }
        public Guid PurchaseId { get; set; }
    }
}

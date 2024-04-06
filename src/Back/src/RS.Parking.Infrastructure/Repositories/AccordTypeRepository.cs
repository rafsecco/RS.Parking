using Microsoft.EntityFrameworkCore;
using RS.Parking.Domain.Contracts;
using RS.Parking.Domain.Models;

namespace RS.Parking.Infrastructure.Repositories;


public class AccordTypeRepository : Repository<AccordType>, IAccordTypeRepository
{
	public AccordTypeRepository(RSParkingContext context) : base(context) { }
}
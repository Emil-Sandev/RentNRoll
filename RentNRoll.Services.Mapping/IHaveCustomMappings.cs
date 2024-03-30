using AutoMapper;

namespace RentNRoll.Services.Mapping
{
	public interface IHaveCustomMappings
	{
		void CreateMappings(IProfileExpression configuration);
	}
}

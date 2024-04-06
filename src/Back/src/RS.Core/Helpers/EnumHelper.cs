using RS.Core.Extensions;

namespace RS.Core.Helpers;

public class EnumHelper<T> where T : Enum
{
	public static IEnumerable<T> GetAllValuesAsIEnumerable()
	{
		return Enum.GetValues(typeof(T)).Cast<T>();
	}
}

public class EnumDTO
{
	public int Id { get { return Convert.ToInt32(_enum); } }
	//public string Name { get { return _enum.ToString(); } }
	public string Description { get { return _enum.ToDescription(); } }

	private Enum _enum;

	public EnumDTO(Enum inputEnum)
	{
		_enum = inputEnum;
	}
}
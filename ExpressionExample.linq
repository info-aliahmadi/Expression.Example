<Query Kind="Program">
  <RuntimeVersion>7.0</RuntimeVersion>
</Query>

void Main()
{
	var someClass = new SomeClass()
	{
		Word = "Hello World",
		Number = 25456

	};

	var selectProperty = "word";

	if (selectProperty == "word")
	{
		someClass.Word.Dump();
	}
	else if (selectProperty == "number")
	{
		someClass.Number.Dump();
	}
	
	// solution : ?
	
	// parammeter
	var parameter = Expression.Parameter(typeof(SomeClass));
	var accessor = Expression.PropertyOrField(parameter , selectProperty);
	var lambda = Expression.Lambda(accessor, false , parameter);
	lambda.Compile().DynamicInvoke(someClass).Dump();
	
}
public class SomeClass
{
	public int Number { get; set; }
	public string Word { get; set; }

}

// You can define other methods, fields, classes and namespaces here
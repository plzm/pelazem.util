![Build](https://github.com/plzm/pelazem.util/actions/workflows/build.yml/badge.svg)  
![Validate Workflows](https://github.com/plzm/pelazem.util/actions/workflows/validate-workflows.yml/badge.svg)  

## Utility Library

pelazem.util: a C# utility library targeting .NET 6.0 and .NET Standard 2.1.

- Class/Base.cs: a simple abstract base class which implements a property change notification pattern. Includes a toggle to fire events (useful to turn off in certain bulk scenarios) and a semaphore whether the object is in a property changed state.
- Configuration/ConfigUtil.cs: implements configuration build with optional JSON settings file and environment variables.
- Extension/CollectionExtensionMethods.cs: extension methods for ICollection<T>, IEnumerable<T>, IDictionary<TKey, TValue>. Add items in bulk; get list as a delimited string with specified delimiter and other capabilities.
- Extension/EncodingExtensionMethods.cs: extension methods for System.Text.Encoding to base64 encode/decode.
- Extension/ReflectionExtensionMethods.cs: extension methods for System.Reflection.PropertyInfo to get or set property values through reflection.
- Constants.cs: a few common string format codes.
- Converter.cs: yet another safe type converter. Includes string to Timespan converter that includes some error checking and other smarts.
- ErrorUtil.cs: utility methods to prettify Exception messages into strings suitable for display or external storage.
- OpResult.cs: a result class to return rich result data from methods in a standard, non-ref way.
- TypeUtil.cs: lots of type and reflection utility methods, including checks whether a PropertyInfo or Type is numeric or primitive, getting type aliases, reflecting over a type to get its properties (all or just primitive or complex), ref type value comparisons, and property value setter with conversion of passed value to property type, and getting a property from a property selector Expression<Func<T>>.
- ValidationResult.cs: helper for classes which need to track whether their properties are in a valid state, and quickly getting validity status.

---

### PLEASE NOTE STANDARD DISCLAIMER FOR THE ENTIRETY OF THIS REPOSITORY AND ALL ASSETS
#### 1. No warranties or guarantees are made or implied.
#### 2. All assets here are provided by me "as is". Use at your own risk.
#### 3. I am not representing my employer with any files, code, or other assets here, and my employer assumes no liability whatsoever for any use of these files, code, or assets.
#### 4. DO NOT USE ANY ASSET HERE IN A PRODUCTION ENVIRONMENT WITHOUT APPROPRIATE REVIEWS, TESTS, and APPROVALS IN YOUR ENVIRONMENT.

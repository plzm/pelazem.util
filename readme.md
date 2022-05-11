[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://github.com/plzm/pelazem.util/blob/main/LICENSE)  
![Validate GHA Workflows](https://github.com/plzm/pelazem.util/actions/workflows/validate-workflows.yml/badge.svg)  
![Build and Test](https://github.com/plzm/pelazem.util/actions/workflows/build-test.yml/badge.svg)  
![Tag](https://github.com/plzm/pelazem.util/actions/workflows/tag.yml/badge.svg)  
[![CodeFactor](https://www.codefactor.io/repository/github/plzm/pelazem.util/badge)](https://www.codefactor.io/repository/github/plzm/pelazem.util)  
![Code Coverage](https://img.shields.io/endpoint?url=https://gist.githubusercontent.com/plzm/3ab4e24d2617826260a3536b2e456d12/raw/pelazem.util.tests.coverage.json)  
[![Codecov.io](https://codecov.io/gh/plzm/pelazem.util/branch/main/graph/badge.svg?token=7M2A9GV73P)](https://codecov.io/gh/plzm/pelazem.util)  

## Utility Library

pelazem.util: a C# utility library with build targets for .NET 6.0 and .NET Standard 2.1.

- [Class/Base.cs](src/pelazem.util/Class/Base.cs): a simple abstract base class which implements a property change notification pattern. Includes a toggle to fire events (useful to turn off in certain bulk scenarios) and a semaphore whether the object is in a property changed state.
- [Configuration/ConfigUtil.cs](src/pelazem.util/Configuration/ConfigUtil.cs): implements configuration build with optional JSON settings file and environment variables.
- [Extension/CollectionExtensionMethods.cs](src/pelazem.util/Extension/CollectionExtensionMethods.cs): extension methods for ICollection<T>, IEnumerable<T>, IDictionary<TKey, TValue>. Add items in bulk; get list as a delimited string with specified delimiter and other capabilities.
- [Extension/EncodingExtensionMethods.cs](src/pelazem.util.tests/EncodingExtensionMethodTests.cs): extension methods for System.Text.Encoding to base64 encode/decode.
- [Extension/ReflectionExtensionMethods.cs](src/pelazem.util/Extension/ReflectionExtensionMethods.cs): extension methods for System.Reflection.PropertyInfo to get or set property values through reflection.
- [Constants.cs](src/pelazem.util/Constants.cs): a few common string format codes.
- [Converter.cs](src/pelazem.util/Converter.cs): yet another safe type converter. Includes string to Timespan converter that includes some error checking and other smarts.
- [ErrorUtil.cs](src/pelazem.util/ErrorUtil.cs): utility methods to prettify Exception messages into strings suitable for display or external storage.
- [OpResult.cs](src/pelazem.util/OpResult.cs): a result class to return rich result data from methods in a standard, non-ref way.
- [TypeUtil.cs](src/pelazem.util/TypeUtil.cs): lots of type and reflection utility methods, including checks whether a PropertyInfo or Type is numeric or primitive, getting type aliases, reflecting over a type to get its properties (all or just primitive or complex), ref type value comparisons, and property value setter with conversion of passed value to property type, and getting a property from a property selector Expression<Func<T>>.
- [ValidationResult.cs](src/pelazem.util/ValidationResult.cs): helper for classes which need to track whether their properties are in a valid state, and quickly getting validity status.

---

### PLEASE NOTE STANDARD DISCLAIMER FOR THE ENTIRETY OF THIS REPOSITORY AND ALL ASSETS
#### 1. No warranties or guarantees are made or implied.
#### 2. All assets here are provided by me "as is". Use at your own risk.
#### 3. I am not representing my employer with any files, code, or other assets here, and my employer assumes no liability whatsoever for any use of these files, code, or assets.
#### 4. DO NOT USE ANY ASSET HERE IN A PRODUCTION ENVIRONMENT WITHOUT APPROPRIATE REVIEWS, TESTS, and APPROVALS IN YOUR ENVIRONMENT.

---

##### Apps and Marketplace Actions

**Whitesource**  
Using: https://www.whitesourcesoftware.com/repo-integration/

**GHA Linter**  
Using: https://github.com/marketplace/actions/github-actions-linting
Repo: https://github.com/cfy9/action-linting

**Code Coverage badge.**  
Using: https://github.com/marketplace/actions/net-code-coverage-badge  
Repo: https://github.com/simon-k/dotnet-code-coverage-badge  

**Codecov.io**  
Using: https://github.com/marketplace/actions/codecov
Repo: https://github.com/codecov/codecov-action

**Codefactor**
Using: https://github.com/marketplace/codefactor

**Add Git Tag**  
Using: https://github.com/marketplace/actions/add-git-tag
Repo: https://github.com/cardinalby/git-tag-action

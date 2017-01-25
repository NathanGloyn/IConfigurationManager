# IConfigurationManager

A wrapper for ConfigurationManager or WebConfigurationManager to help with unit testing and dependency injection

## Why?

Although the standard Configuration classes in .Net are very powerful and useful they have some drawbacks in that because they are static they effectively become hidden dependencies in the code leading it to be tightly coupled to these classes but with no visibility that the coupling exists.

## So what does IConfigurationManager do?

The solution provides an interface for access AppSettings, ConnectionStrings and retrieving custom sections in a strongly typed way.

Two adapters are provided for the standard ConfigurationManger and the WebConfigurationManager that implement the interface, this allows you inject the class making a dependency visible and allowing you to mock/stub the dependency for testing.

## What is IConfigurationManagerExtension?

This interface provides access to additional functionality around configuration settings that is not part of the normal ConfigurationManager functionality.

## License

This software is licensed under the MIT license which basically means you can do what you want
with the software, read the license.txt for full details.

## Helpful links

-- Artical
https://www.codeproject.com/articles/196563/don-t-use-configurationmanager

-- Source
https://github.com/NathanGloyn/IConfigurationManager

-- How to config VS to use SymbolSource for debugging.
http://www.symbolsource.org/Public/Home/VisualStudio

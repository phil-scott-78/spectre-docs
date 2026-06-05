---
Title: Spectre.Console 0.56.0 released!
Description: Still not written in Rust.
Date: 2026-06-06
---

Version 0.56.0 of Spectre.Console has been released!

While Spectre.Console is in stabilization mode i.e. fixing bugs
and hardening things, a tiny new feature sneaked in as well!

## New Figlet layout modes

In this release we've added new layout modes for FigletText.
The two new modes are `Fitted` and `Smushed` which will make 
the Figlet text take up less space and look "smoother".

## What's Changed

* Ensure redirected output works as expected by [@patriksvensson](https://github.com/patriksvensson) in [#2098](https://github.com/spectreconsole/spectre.console/pull/2098)
* Add missing text prompt suffix by [@merklegroot](https://github.com/merklegroot) in [#2102](https://github.com/spectreconsole/spectre.console/pull/2102)
* Fix Align measure to respect explicitly set width by [@GrantTotinov](https://github.com/GrantTotinov) in [#2101](https://github.com/spectreconsole/spectre.console/pull/2101)
* Option to exclude vertical padding for live progress renderer by [@james-newell-forge](https://github.com/james-newell-forge) in [#2100](https://github.com/spectreconsole/spectre.console/pull/2100)
* Don't emit ANSI sequence for 0 movement by [@merklegroot](https://github.com/merklegroot) in [#2104](https://github.com/spectreconsole/spectre.console/pull/2104)
* ConfirmationPrompt: Allow submission without Enter key by [@patriksvensson](https://github.com/patriksvensson) in [#2111](https://github.com/spectreconsole/spectre.console/pull/2111)
* Add two new layout modes for FigletText by [@patriksvensson](https://github.com/patriksvensson) in [#2066](https://github.com/spectreconsole/spectre.console/pull/2066)
* Fix escaping of interpolated arguments in markup by [@GrantTotinov](https://github.com/GrantTotinov) in [#2118](https://github.com/spectreconsole/spectre.console/pull/2118)
* Allow validation chaining by [@AntekOlszewski](https://github.com/AntekOlszewski) in [#2116](https://github.com/spectreconsole/spectre.console/pull/2116)
* Fix grid regression where expansion did not work by [@patriksvensson](https://github.com/patriksvensson) in [#2127](https://github.com/spectreconsole/spectre.console/pull/2127)
* Preserve links in segments by [@patriksvensson](https://github.com/patriksvensson) in [#2135](https://github.com/spectreconsole/spectre.console/pull/2135)

## New Contributors

* [@merklegroot](https://github.com/merklegroot) made their first contribution in [#2102](https://github.com/spectreconsole/spectre.console/pull/2102)
* [@GrantTotinov](https://github.com/GrantTotinov) made their first contribution in [#2101](https://github.com/spectreconsole/spectre.console/pull/2101)
* [@james-newell-forge](https://github.com/james-newell-forge) made their first contribution in [#2100](https://github.com/spectreconsole/spectre.console/pull/2100)

**Full Changelog**: https://github.com/spectreconsole/spectre.console/compare/0.55.2...0.56.0
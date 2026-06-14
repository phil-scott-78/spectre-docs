---
title: Spectre.Console 0.57.0 released!
description: Contents may have settled during shipping.
date: 2026-06-11
---

Version 0.57.0 of Spectre.Console has been released!

This release contains new box borders and a fix for an annoying little bug affecting 
how links are rendered when wrapped inside tables and other widgets. That should be fixed now.

You can see the new box borders in action over here: <xref:console-box-border-reference>

## What's Changed
* Make source generator output deterministic (LF, no BOM) by [@phil-scott-78](https://github.com/phil-scott-78) in [#2143](https://github.com/spectreconsole/spectre.console/pull/2143)
* Add new box border styles including beveled, dashed, dotted, heavy, and rounded variants by [@phil-scott-78](https://github.com/phil-scott-78) in [#2142](https://github.com/spectreconsole/spectre.console/pull/2142)
* Should preserve auto links when wrapped in grid by [@patriksvensson](https://github.com/patriksvensson) in [#2149](https://github.com/spectreconsole/spectre.console/pull/2149)

**Full Changelog**: https://github.com/spectreconsole/spectre.console/compare/0.56.0...0.57.0
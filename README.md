# PHP Checks Tool
This is a utility tool designed to streamline the process of interacting with PHP-related tools:

- Git
- PHP Stan
- PHP Code Sniffer

## Installation

 1. Identify the version of the tool you would like to install from the `Release` directory in the root of the project.
 2. Copy the entire contents of the folder into a folder on your system.
 3. Double-click the `PHP_Checks_Tool.exe` file to run the tool.

To be able to search for the tool in the start menu, create a shortcut for the `exe` file and place it in your `C:\Users\{username}\AppData\Roaming\Microsoft\Windows\Start Menu\Programs` directory.

## Usage - Latest Version

There are two methods of running the core functionality in this tool:

- **Standard** - The default method, that runs the CLI commands and displays the output on the black screen in the tool.
- **Advanced** - Runs the same commands as the Standard method, but the output is displayed in a table view.

### Profiles

This tool makes use of "profiles" which contain the following:

- **Working Directory** - The root folder of your project, this should contain a vendor folder.
- **PHP Stan Commit Message** - The message to be included in the Git commit for PHP Stan (see Git Controls below).
- **PHP CS Commit Message** - The message to be included in the Git commit for Code Sniffer (see Git Controls below).

#### Add a Profile

To add a new profile:

1. From the main tool screen, open the `Settings` menu.
2. Click the `Add New Profile...` option.
3. Enter your profile details.
4. Click the `Save` button.

#### Select a Profile

To select a profile or change profile:

1. From the main tool screen, open the `Settings` menu.
2. Click the profile option you wish to use (not one of the profiles sub-menu options)

The profile will now display a tick next to it when you open the `Settings` menu to indicate that it is the active profile. The tool will remember which profile is active between uses.

#### Edit a Profile

To edit an existing profile:

1. From the main tool screen, open the `Settings` menu.
2. Hover over the profile option you wish to edit to view it's sub-menu.
3. Click the `Edit` option.
4. Edit the profile details (Note: The profile name cannot be changed).
5. Click the `Save` button.

*Note: If you are editing your currently active profile, you may need to re-select the profile or restart in order for the changes to take effect.*

#### Delete a Profile

To delete an existing profile:

1. From the main tool screen, open the `Settings` menu.
2. Hover over the profile option you wish to edit to view it's sub-menu.
3. Click the `Delete` option.
4. Click the `Yes` button on the `Delete Profile` dialog box.

### Git Controls

There are three Git controls included in this tool that are available through the `Git` menu:

- **Status** - The will run the `git status` command in your profile working directory.
- **PHP Stan Commit** - This will run the `git add .` command followed by committing the changes with the PHP Stan message set in your active profile.
- **PHP CS Commit** - This will run the `git add .` command followed by committing the changes with the PHP CS message set in your active profile.

For all of the above commands, the output will be displayed in the black screen on the tool.

### PHP Stan

When running anything to do with PHP Stan, the following command will be run in the background:

    .\vendor\bin\phpstan analyse --configuration=phpstan.neon --memory-limit=1G -v

#### Standard

1. From the main tool screen, click the `PHP Stan` button.
2. The controls will be disabled whilst the command is running and will be enabled again once it is complete.
3. The output from the analysis command will be outputted onto the back screen.

#### Advanced

1. From the main tool screen, open the `Advanced` menu.
2. Click the `PHP Stan Checker` option.
3. Click the `Run PHP Stan` button
4. If there are errors, they will be displayed in the table. If there are no errors, a dialog box will pop up.

You can copy the content of a cell in the table by right-clicking it. For the `File Path` column, you can also choose to copy only the filename rather than the entire path.

### PHP Code Sniffer

When running anything to do with PHP Code Sniffer, the following command will be run in the background:

    .\vendor\bin\phpcs --standard=phpcs.xml src

#### Standard

1. From the main tool screen, click the `PHP CS` button.
2. The controls will be disabled whilst the command is running and will be enabled again once it is complete.
3. The output from the command will be outputted onto the back screen.

#### Advanced

1. From the main tool screen, open the `Advanced` menu.
2. Click the `PHP Code Sniffer` option.
3. Click the `Run PHP CS` button
4. If there are errors, they will be displayed in the table. If there are no errors, a dialog box will pop up.

You can copy the content of a cell in the table by right-clicking it. For the `File Path` column, you can also choose to copy only the filename rather than the entire path.

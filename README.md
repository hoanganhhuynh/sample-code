Step to run the application:
- Run `docker compose up` to init postgres databse or using local postgres sql.
- Run `dotnet ef database update -s TodoAPI -c TodoDbContext -p Infrastructure` to migration database.
- Run seeding script for Country table, the script in Infrastructure/Script.
- Replace the correct ConnectionString to appsetting in TodoAPI project.
- Run the application

**Note:
- The docker compose have not init the application yet. Currently, it is used to init db. Please run your code in local.
- If you still face the CORS issue, please work around with the browser for temporary

    Window:
    "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe" --disable-web-security --disable-gpu --user-data-dir=~/chromeTemp

    Mac:
    open -n -a /Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome --args --user-data-dir="/tmp/chrome_dev_test" --disable-web-security

    Linux:
    google-chrome --disable-web-security
- This is just an example, so I am really sorry if it is not correct or perfect. Thanks for reviewing.

    
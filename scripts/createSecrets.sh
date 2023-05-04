echo "Creating secrets files"
echo "This command only create the secrets directory and empty files"
mkdir secrets
touch secrets/mariadb_password_root.txt
touch secrets/mariadb_password.txt
touch secrets/mongodb_password.txt
touch secrets/mongodb_password_root.txt
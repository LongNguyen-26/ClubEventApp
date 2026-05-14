import os

output_file = "merged_source_code.txt"
# Loại bỏ các thư mục build hoặc code auto-generated
ignored_dirs = ['bin', 'obj', 'Migrations', 'Properties', '.git']

with open(output_file, 'w', encoding='utf-8') as outfile:
    for root, dirs, files in os.walk('.'):
        dirs[:] = [d for d in dirs if d not in ignored_dirs]
        for file in files:
            if file.endswith('.cs'):
                file_path = os.path.join(root, file)
                outfile.write(f"\n{'='*50}\n")
                outfile.write(f"FILE: {file_path}\n")
                outfile.write(f"{'='*50}\n\n")
                with open(file_path, 'r', encoding='utf-8') as infile:
                    outfile.write(infile.read())

print(f"Đã gom code thành công vào file {output_file}")
require_relative './data_file_exception'

module Filestore

	class CatalogueReader

		def initialize(filename)
			@filename = filename
		end

		def read_all
			lines = []
			begin
				File.foreach(@filename) do |line|
					lines << line.split(/\^/)
				end
			rescue Exception => e
				raise DataFileException.new(@filename, e)
			end
			lines
		end

	end
end

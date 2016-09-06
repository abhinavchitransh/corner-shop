require_relative './data_file_exception'

module Filestore

	class CatalogueReader

		def initialize(filename)
			@filename = filename
		end

		def readAll
			lines = []
			begin
				File.foreach(@filename) do |line|
					args = line.split(/\^/)
					lines << args
				end
			rescue Exception => e
				throw DataFileException.new(@filename, e)
			end
			lines
		end

	end
end
